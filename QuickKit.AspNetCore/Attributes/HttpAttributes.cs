using Microsoft.AspNetCore.Mvc;
using QuickKit.AspNetCore.Constants.Endpoints;

namespace QuickKit.AspNetCore.Attributes;

#region GetAll
/// <summary>
/// Represents an attribute that specifies an HTTP GET request to retrieve all data.
/// <para>Does not define the data.</para>
/// <para>Does not define the response.</para>
/// <para>Uses the naming convention from <see cref="ENDPOINT_NAME.GET_ALL"/></para>
/// </summary>
[AttributeUsage(AttributeTargets.Method)]
public class GetAll : HttpGetAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetAll"/> class with the specified template.
    /// </summary>
    /// <param name="template">The template for the endpoint.</param>
    public GetAll(string template = ENDPOINT_NAME.GET_ALL) : base(template)
    {
    }
}
#endregion

#region GetById
/// <summary>
/// Represents an attribute that specifies an HTTP GET request for retrieving a resource by its ID.
/// <para>Does not define the data.</para>
/// <para>Does not define the response.</para>
/// <para>Uses the naming convention from <see cref="ENDPOINT_NAME.GET_BY_ID"/></para>
/// </summary>
[AttributeUsage(AttributeTargets.Method)]
public class GetById : HttpGetAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetById"/> class with the specified template.
    /// 
    /// <para>Does not define the data.</para>
    /// <para>Does not define the response.</para>
    /// <para>Uses the naming convention from <see cref="ENDPOINT_NAME.GET_BY_ID"/></para>
    /// </summary>
    /// <param name="template">The template for the endpoint.</param>
    public GetById(string template = ENDPOINT_NAME.GET_BY_ID) : base(template)
    { }
}

#endregion

#region TestEndPoint
/// <summary>
/// Represents an attribute that specifies an HTTP GET for test endpoint.
/// <para>Does not define the data.</para>
/// <para>Does not define the response.</para>
/// <para>Uses the naming convention from <see cref="ENDPOINT_NAME.TEST"/></para>
/// </summary>
[AttributeUsage(AttributeTargets.Method)]
public class TestEndPoint : HttpGetAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TestEndPoint"/> class with the specified template.
    /// </summary>
    /// <param name="template">The template for the endpoint.</param>
    public TestEndPoint(string template = ENDPOINT_NAME.TEST) : base(template)
    { }
}

#endregion

#region Add
/// <summary>
/// Represents an attribute that is used to add a resource using HTTP POST method.
/// <para>Does not define the data.</para>
/// <para>Does not define the response.</para>
/// <para>Uses the naming convention from <see cref="ENDPOINT_NAME.ADD"/></para>
/// </summary>
[AttributeUsage(AttributeTargets.Method)]
public class Add : HttpPostAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Add"/> class with the specified template.
    /// </summary>
    /// <param name="template">The template for the endpoint.</param>
    public Add(string template = ENDPOINT_NAME.ADD) : base(template)
    { }
}

#endregion

#region Update
/// <summary>
/// Represents an attribute that is used to decorate a method as an HTTP update endpoint.
/// <para>Does not define the data.</para>
/// <para>Does not define the response.</para>
/// <para>Uses the naming convention from <see cref="ENDPOINT_NAME.UPDATE"/></para>
/// </summary>
[AttributeUsage(AttributeTargets.Method)]
public class Update : HttpPutAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Update"/> class with the specified template.
    /// </summary>
    /// <param name="template">The template for the endpoint.</param>
    public Update(string template = ENDPOINT_NAME.UPDATE) : base(template)
    { }
}

#endregion

#region Delete

/// <summary>
/// Represents an attribute that specifies that an action method should be accessible via HTTP DELETE requests.
/// <para>Does not define the data.</para>
/// <para>Does not define the response.</para>
/// <para>Uses the naming convention from <see cref="ENDPOINT_NAME.DELETE"/></para>
/// </summary>
[AttributeUsage(AttributeTargets.Method)]
public class Delete : HttpDeleteAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Delete"/> class with the specified template.
    /// </summary>
    /// <param name="template">The template for the endpoint.</param>
    public Delete(string template = ENDPOINT_NAME.DELETE) : base(template)
    { }
}

#endregion