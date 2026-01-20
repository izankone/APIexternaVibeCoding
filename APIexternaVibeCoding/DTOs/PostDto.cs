namespace APIExternaVibeCoding.DTOs
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        // Aquí podrías decidir NO incluir el UserId si no quieres mostrarlo
    }
}