using UnityEngine;

public class ControlePassaro : MonoBehaviour
{
    // Força do impulso para cima
    public float forcaDoPulo = 5f;
    private Rigidbody rb;
    private bool jogoComecou = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Começa sem gravidade para ficar parado no menu (Modo Espera)
        
    }

    void Update()
    {
        // Se o jogador clicar em Jogar na UI, o jogo ativa (faremos isso no passo da UI)
        
            // Verifica se apertou Espaço OU se clicou com o botão esquerdo do mouse
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                // Zera a velocidade atual antes de dar o impulso para o pulo ser consistente
                rb.linearVelocity = (Vector3.up * forcaDoPulo);
               
            }
    }

    // Função simples para o botão de Jogar chamar
    
}