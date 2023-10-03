using UnityEngine;

public class SwingingDoor : MonoBehaviour
{
    public float swingAngle = 90f;  // Angle maximal de rotation pour l'ouverture de la porte
    public float openSpeed = 50f;  // Vitesse d'ouverture de la porte
    public float closeSpeed = 10f;  // Vitesse de fermeture de la porte

    private bool isOpening = false;
    private bool isClosing = false;
    private Quaternion initialRotation;
    private Quaternion targetRotation;

    void Start()
    {
        initialRotation = transform.rotation;
        targetRotation = Quaternion.Euler(0, swingAngle, 0) * initialRotation;
    }

    void Update()
    {
        if (isOpening)
        {
            // Ouvrir progressivement la porte dans la direction du joueur
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, openSpeed * Time.deltaTime);

            // Vérifiez si la porte est entièrement ouverte
            if (Quaternion.Angle(transform.rotation, targetRotation) < 1f)
            {
                isOpening = false;  // La porte est entièrement ouverte, arrêtez l'ouverture
                isClosing = true;   // Commencez la fermeture
            }
        }

        if (isClosing)
        {
            // Fermer progressivement la porte en revenant à la position initiale
            transform.rotation = Quaternion.RotateTowards(transform.rotation, initialRotation, closeSpeed * Time.deltaTime);

            // Vérifiez si la porte est entièrement fermée
            if (Quaternion.Angle(transform.rotation, initialRotation) < 1f)
            {
                isClosing = false;  // La porte est entièrement fermée
            }
        }
    }

    // Méthode pour ouvrir la porte dans la direction du joueur
    public void OpenDoor()
    {
        isOpening = true;
    }

    // Détecter le joueur qui entre dans le déclencheur
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OpenDoor();  // Ouvrir la porte lorsque le joueur entre dans le déclencheur

            // Mettez à jour la rotation de la porte pour faire face au joueur
            Vector3 directionToPlayer = other.transform.position - transform.position;
            Quaternion newRotation = Quaternion.LookRotation(directionToPlayer, Vector3.up);
            targetRotation = newRotation;
        }
        if (other.CompareTag("Zombie"))
        {
            OpenDoor();  // Ouvrir la porte lorsque le joueur entre dans le déclencheur

            // Mettez à jour la rotation de la porte pour faire face au joueur
            Vector3 directionToPlayer = other.transform.position - transform.position;
            Quaternion newRotation = Quaternion.LookRotation(directionToPlayer, Vector3.up);
            targetRotation = newRotation;
        }
    }
}
