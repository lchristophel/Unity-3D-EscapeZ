using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    public float movementSpeed = 3f; // Vitesse du zombie
    public float obstacleDetectionRange = 2f; // Distance de détection des obstacles par le zombie
    public float playerDetectionRange = 5f; // Distance de détection du joueur par le zombie
    public float changeDirectionInterval = 1.5f; // Interval pour que le zombie change de direction
    public float playerDeathDistance = 1f; // Distance entre le zombie et le joueur pour qu'il meurt
    public AudioSource playerAudioSource; // L'audio source du joueur
    public AudioSource ambientAudioSource; // L'audio source de l'ambiance
    public AudioClip deathSound; // L'audio clip lors de la mort du joueur
    public AudioClip zombieSound; // L'audio clip du son du zombie
    public GameObject deathScreen; // GO de l'écran de mort
    public Rigidbody playerRigidbody; // Rb du joueur
    public FirstPersonLook firstPersonLook; // Script de vision FPS
    public float soundDistance = 10f; // Distance à partir de laquelle on peut entendre le zombie
    public float fadeDuration = 1.0f; // Durée du fondu du son
    
    private bool isFollowingPlayer = false; // Est en train de suivre le joueur ?
    private float timer; // Timer
    private AudioSource audioSource; // L'AudioSource du zombie
    private Animator animator; // Animator
    private Transform player; // Infos du joueur (Position / taille etc.)
    private Vector3 currentDirection; // Position en cours 
    private float initialVolume; // Volume initial du son du zombie

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Récupérer l'AudioSource du zombie
        audioSource.clip = zombieSound; // Assigner l'audio clip à la variable zombieSound
        initialVolume = audioSource.volume; // Récupérer le volume initial du son du zombie
        timer = changeDirectionInterval;
        animator = GetComponent<Animator>(); // Récupérer l'animator du zombie
        player = GameObject.FindGameObjectWithTag("Player").transform; // Récupération de la position du joueur via le tag
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            currentDirection = Random.insideUnitSphere;
            currentDirection.y = 0f;
            currentDirection.Normalize();

            timer = changeDirectionInterval;
        }

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Si le joueur est à portée
        if (distanceToPlayer <= playerDetectionRange)
        {
            transform.LookAt(player); // orientez le zombie vers le joueur
            currentDirection = (player.position - transform.position).normalized; // et suivez-le
            
            isFollowingPlayer = true; // Le zombie est en train de suivre le joueur
            
            if (!audioSource.isPlaying) // Si l'audioSource n'est pas en train de jouer un son
            {
                audioSource.Play(); // Jouer le son du zombie
            }

            if (distanceToPlayer <= playerDeathDistance) // Si la distance du joueur entre le joueur et le zombie est faible
            {
                PlayerDeath(); // Appeler la fonction de mort du joueur
            }
        }
        else // Sinon le zombie n'est plus en train de suivre le joueur
        {
            isFollowingPlayer = false;
        }

        // Ajuster le volume du son du zombie en fonction de la distance
        if (isFollowingPlayer && distanceToPlayer <= soundDistance)
        {
            if (!audioSource.isPlaying) // Si le zombie n'est pas déjà en train de faire du bruit
            {
                audioSource.Play(); // Activer le son du zombie
            }
            // Ajuster progressivement le volume vers le haut
            audioSource.volume = Mathf.Lerp(audioSource.volume, initialVolume, Time.deltaTime / fadeDuration);
        }
        else
        {
            // Si le zombie est trop éloigné, diminuer progressivement le volume
            audioSource.volume = Mathf.Lerp(audioSource.volume, 0f, Time.deltaTime / fadeDuration);
            if (audioSource.volume < 0.01f)
            {
                audioSource.Stop(); // Arrêter le son du zombie si le volume est très bas
            }
        }

        MoveZombie(currentDirection); // Appeler la fonction pour bouger le zombie en lui donnant le paramètre de la direction en cours
    }

    private void MoveZombie(Vector3 direction)
    {
        if (isFollowingPlayer) // Si le zombie est en train de suivre le joueur
        {
            // Déplacer le zombie dans la direction du joueur
            transform.Translate(direction * movementSpeed * Time.deltaTime, Space.World);

            // Orienter le zombie dans la direction du mouvement
            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.1f);
            }
        }
        else // Sinon
        {
            // Retourner à la détection des obstacles (murs et portes) pour recherche active du joueur
            if (Physics.Raycast(transform.position, direction, out RaycastHit hit, obstacleDetectionRange))
            {
                if (hit.collider.CompareTag("Wall")) // Si le tag du collider dans le champ de raycast du zombie est wall
                {
                    currentDirection = Vector3.Reflect(direction, hit.normal); // Eviter et refléction du mouvement dans un autre sens
                }
                else if (hit.collider.CompareTag("Door")) // Si le tag du collider est door
                {
                    // Déplacer le zombie pour traverser la porte
                    transform.Translate(direction * movementSpeed * Time.deltaTime, Space.World);
                }
            }
            else
            {
                // Déplacer le zombie dans la direction spécifiée
                transform.Translate(direction * movementSpeed * Time.deltaTime, Space.World);
            }
            if (direction != Vector3.zero) // Orienter le zombie dans la direction du mouvement
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.1f);
            }
        }
    }

    public void PlayerDeath()
    {
        Cursor.visible = true; // A la mort du joueur, le curseur de la souris devient visible
        Cursor.lockState = CursorLockMode.Confined; // Le curseur est confiné dans la fenêtre de jeu (CursorLockMode.Locked = mode capturé)
        deathScreen.SetActive(true); // Activer le Game Object pour afficher l'écran de Game Over
        playerRigidbody.isKinematic = true; // Geler le rb du joueur pour l'empêcher de bouger
        audioSource.Stop(); // Stopper le son du zombie
        ambientAudioSource.Stop(); // Stopper le son de l'ambiance
        Time.timeScale = 0f; // Arrêter l'écoulement du temps
        if(playerRigidbody != null && firstPersonLook != null) // Si le rigidbody du joueur existe et que le script de vision FPS aussi 
        {   
            firstPersonLook.enabled = false; // Désactiver la possibilité de bouger la vue (FPS)
        }
        if (!playerAudioSource.isPlaying) // Si l'audioSource du joueur n'est pas en train de jouer un son
        {
            playerAudioSource.Play(); // Jouer le son de d'ambiance, de musique et du zombie pour la Game Over
        }
    }
}
