namespace APIExternaVibeCoding.DTOs
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        // Aquí podrías decidir NO incluir el UserId si no quieres mostrarlo
    }
}