using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net.Http.Json;

namespace IntegrationTest
{
    public class TaskTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public TaskTest(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetTasks_ShouldReturnSuccess()
        {
            // Act
            var response = await _client.GetAsync("/api/Tasks");

            // Assert
            response.EnsureSuccessStatusCode();
        }
        [Fact]
        public async Task CreateTask_ShouldReturnSuccess()
        {
            // Arrange
            var task = new
            {
                taskName = "Integration Test Task",
                desc = "Created by integration test"                
            };

            // Act
            var response = await _client.PostAsJsonAsync("/api/Tasks", task);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task UpdateTask_ShouldReturnSuccess()
        {
            // Arrange
            var task = new
            {
                taskName = "Updated Task",
                desc = "Updated by integration test",
                isCompleted = true
            };

            // Act
            var response = await _client.PutAsJsonAsync("/api/Tasks/5", task);

            // Assert
            response.EnsureSuccessStatusCode();
        }
        [Fact]
        public async Task DeleteTask_ShouldReturnSuccess()
        {
            // Act
            var response = await _client.DeleteAsync("/api/Tasks/4");

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
