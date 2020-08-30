using GameTOP.Interface;

namespace GameTOP.Lib
{
  public class Jogador2 : iJogador
  {
    public string Chuta()
    {
      return "Maradone esta pateando";
    }

    public string Corre()
    {
      return "Maradone esta corriendo";
    }

    public string Passe()
    {
      return "Maradone esta pasando";
    }
  }
}