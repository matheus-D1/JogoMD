using UnityEngine;

public class GeradorDeCanos : MonoBehaviour
{
    public GameObject canoConeccaoNormal;
    public GameObject canoConeccaoEspecial;

    public float tempoEntreSpawn = 2f;
    private float cronometroSpawn;
    private float tempoDeSobrevivencia;
    private bool podeGerar = false;

    void Update()
    {
        if (!podeGerar) return;

        // Conta o tempo total da partida (Dificuldade Temporal)
        tempoDeSobrevivencia += Time.deltaTime;

        // Cronômetro para o nascimento de cada cano
        cronometroSpawn += Time.deltaTime;

        if (cronometroSpawn >= tempoEntreSpawn)
        {
            SpawnarCano();
            cronometroSpawn = 0f; // Reseta o cronômetro
        }
    }

    void SpawnarCano()
    {
        Vector3 posicaoSpawn = transform.position; // Posição do Gerador

        // Fase 1: Introdução (Menos de 20 segundos)
        if (tempoDeSobrevivencia <= 20f)
        {
            Instantiate(canoConeccaoNormal, posicaoSpawn, Quaternion.identity);
        }
        // Fase 2: Caos Vertical (Após 20 segundos)
        else
        {
            // Sorteio de 50% de chance (Random.value vai de 0.0 a 1.0)
            if (Random.value > 0.5f)
            {
                Instantiate(canoConeccaoEspecial, posicaoSpawn, Quaternion.identity);
            }
            else
            {
                Instantiate(canoConeccaoNormal, posicaoSpawn, Quaternion.identity);
            }
        }
    }

    public void IniciarGerador()
    {
        podeGerar = true;
    }
}