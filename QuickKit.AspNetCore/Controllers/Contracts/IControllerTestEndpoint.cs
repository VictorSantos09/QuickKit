using Microsoft.AspNetCore.Mvc;

namespace QuickKit.AspNetCore.Controllers.Contracts;

public interface IControllerTestEndpoint
{
    /// <summary>
    /// Tests the endpoint of the controller.
    /// </summary>
    /// <returns>An <see cref="IActionResult"/> representing the result of the test.</returns>
    IActionResult TestEndPoint();
}

