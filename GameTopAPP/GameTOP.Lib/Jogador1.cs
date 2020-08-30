using GameTOP.Interface;

namespace GameTOP.Lib
{
    public class Jogador1 : iJogador
    {
        public readonly string _Nome;

        public Jogador1(string nome = "Ronaldo")
        {
          _Nome = nome;
        }

        //Chuta
        public string Chuta()
        {
          return $"{_Nome} esta chutando \n";
        }
        //Corre
        public string Corre()
        {
          return $"{_Nome} esta correndo \n";
        }
        //Passe
        public string Passe()
        {
          return $"{_Nome} esta passando \n";
        }
    }
}