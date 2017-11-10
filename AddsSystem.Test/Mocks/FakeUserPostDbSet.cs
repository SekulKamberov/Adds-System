namespace AddsSystem.Test.Mocks
{
    using AddsSystem.Models.EntityModels;
    using System.Linq;

    public class FakeUserPostDbSet : FakeDbSet<UserPost>
    {
        //public override UserPost Find(params object[] keyValues)
        //{
        //    int wantedId = (int)keyValues[0];
        //    return this.Set.FirstOrDefault(userpost => userpost.Id == wantedId);
        //}
    }
}
