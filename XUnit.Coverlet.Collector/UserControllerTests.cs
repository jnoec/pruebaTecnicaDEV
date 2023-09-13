namespace XUnit.Coverlet.Collector
{ 
     public class UserControllerTests
    {
        private readonly UserController _userController;
        private DbContextOptions<UserContext>? _dbContextOptions;
        private UserController userController;

        public UserControllerTests()
        {
            var dbName = $"UserContext_{DateTime.Now.ToFileTimeUtc()}";
            _dbContextOptions = new DbContextOptionsBuilder<UserContext>()
                .UseInMemoryDatabase(dbName)
                .Options;

            var userContext = new UserContext(_dbContextOptions);
            userController = new UserController(userContext);
        }

        [Fact]
        public void Getstrings_ReturnsOkResult()
        {
            // Act
            var result = userController.Getstrings();
            // Assert
            Assert.Equal(0, result.Value.Count);
        }

        [Fact]
        public void GetstringById_ReturnsNotFoundResult()
        {
            // Arrange
            var id = 1;
            // Act
            var result = userController.GetstringById(id);
            // Assert
            Assert.Equal(null, result.Value);
        }

        [Fact]
        public void Poststring_ReturnsOkResult()
        {
            // Arrange
            var user = new User { Id = 1, Name = "Test3", Email = "test3@test.com", Password = "TestPass3" };
            // Act
            var result = userController.Poststring(user);
            // Assert
            Assert.Equal(user.Id, result.Id);
            Assert.Equal(user.Name, result.Name);
            Assert.Equal(user.Email, result.Email);
            Assert.Equal(user.Password, result.Password);
        }

        [Fact]
        public void Putstring_ReturnsOkResult()
        {
            // Arrange
            var user = new User { Id = 1, Name = "Test3", Email = "test3@test.com", Password = "TestPass3" };
            var id = 1;
            var userToUpdate = new User { Id = 1, Name = "UpdatedTest2", Email = "updatedtest2@test.com", Password = "UpdatedTestPass2" };
            // Act
            userController.Poststring(user);
            var result = userController.Putstring(id, userToUpdate);
            // Assert
            Assert.Equal(userToUpdate.Id, result.Value.Id);
            Assert.Equal(userToUpdate.Name, result.Value.Name);
            Assert.Equal(userToUpdate.Email, result.Value.Email);
            Assert.Equal(userToUpdate.Password, result.Value.Password);
        }

        [Fact]
        public void DeletestringById_ReturnsOkResult()
        {
            // Arrange
            var user = new User { Id = 1, Name = "Test3", Email = "test3@test.com", Password = "TestPass3" };
            var id = 1;
            // Act
            userController.Poststring(user);
            var result = userController.DeletestringById(id);
            // Assert
            Assert.Equal(id, result.Value);
        }
    }
}