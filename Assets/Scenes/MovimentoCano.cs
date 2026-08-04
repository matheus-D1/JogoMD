using UnityEngine;

public class MovimentoCano : MonoBehaviour
{
    // Velocidade de movimento para a esquerda da sua tela
    public float velocidadeHorizontal = 5f;

    // Define se este é o cano com movimento caótico (Fase 2 do GDD)
    public bool ehEspecial = false;

    private float velocidadeVertical;
    private int direcaoVertical = 1; // 1 para subir, -1 para descer

    void Start()
    {
        // Se a engine sortear o Cano Especial, define a velocidade e direção vertical
        if (ehEspecial)
        {
            velocidadeVertical = Random.Range(1f, 4f); // Velocidade aleatória vertical
            if (Random.value > 0.5f) direcaoVertical = -1; // Sorteia se começa subindo ou descendo
        }

        // Destrói o cano após 7 segundos para evitar acúmulo de objetos na memória
        Destroy(gameObject, 7f);
    }

    void Update()
    {
        // MOVE PARA A ESQUERDA DA SUA CENA: Altera a posição no eixo Z positivo
        transform.position += new Vector3(0, 0, velocidadeHorizontal * Time.deltaTime);

        // MOVIMENTO VERTICAL: Executado no eixo Y apenas pelo Cano Especial
        if (ehEspecial)
        {
            transform.position += new Vector3(0, direcaoVertical * velocidadeVertical * Time.deltaTime, 0);
        }
    }
}