namespace api;

public interface ICommentRepository
{
    Task<List<Comment>> GetAllAsync();
}
