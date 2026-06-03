namespace ApiMangas.DTOs
{
    public class MangaPaginacaoResponseDTO
    {
        public List<MangaDTO>? Mangas { get; set; }
        public int TotalPaginas { get; set; }
    }
}
