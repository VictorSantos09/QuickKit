namespace Classroom.Core.GraphQL.Queries.Base
{
    public class Query
    {
        public async Task<string> HelloWorld()
        {
            return await Task.Run(() =>
            {
                return "Hello World!";
            });
        }
    }
}
