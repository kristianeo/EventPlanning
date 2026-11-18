namespace EventPlanning.UserTest;

public class FakeCurrentUser : ICurrentUser
{
    public int UserId
    {
        get => 1;
        set => throw new NotImplementedException();
    }
}