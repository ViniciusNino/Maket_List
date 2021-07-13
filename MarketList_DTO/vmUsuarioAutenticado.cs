namespace MarketList_DTO
{
    public class vmUsuarioAutenticado
    {
        public int nIdUsuarioAutenticado { get; set; }
        public string sNome { get; set; }
        public int nIdPerfilUsuario { get; set; }

        public int? nIdUnidade { get; set; }

        public string sNomeUnidade { get; set; }
    }
}