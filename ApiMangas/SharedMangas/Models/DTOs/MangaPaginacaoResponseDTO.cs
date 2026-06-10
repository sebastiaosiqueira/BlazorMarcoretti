

using SharedMangas.Models.DTOs;

namespace SharedMangas.DTOs
{
    public class MangaPaginacaoResponseDTO
    {
        public List<MangaDTO>? Mangas { get; set; }
        public int TotalPaginas { get; set; }
    }
}
