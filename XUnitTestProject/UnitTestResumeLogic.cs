using BussinesLogic.Logics;
using DAL.Entities;
using DAL.Interfaces;
using Moq;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace XUnitTestProject
{
    //AddResume GetAllResumes GetResume DeleteResume EditResume
    public class UnitTestResumeLogic
    {
        [Fact]
        public void GetResumes()
        {  
            // Arrange
            List<Resume> resumes = new List<Resume>();
            resumes.Add(new Resume());
            resumes.Add(new Resume());
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(a => a.Resumes.GetAll()).Returns(resumes);
            ResumeLogic logic = new ResumeLogic(mock.Object);

            // Act
            var result = logic.GetAllResumes();

            // Assert
            Assert.Equal(2, result.Count());
        }
        [Fact]
        public void AddResume()
        {
            Resume resume = new Resume();
            var mock = new Mock<IUnitOfWork>();
            ResumeLogic resumeLogic = new ResumeLogic(mock.Object);

            resumeLogic.AddResume(resume);

            mock.Verify(t => t.Resumes.Add(resume));   
        }
        [Fact]
        public void GetResume()
        {
            // Arrange
            var mock = new Mock<IUnitOfWork>();
            Resume resume = new Resume();

            mock.Setup(a => a.Resumes.Get(It.IsAny<int>())).ReturnsAsync(resume);
            ResumeLogic resumeLogic = new ResumeLogic(mock.Object);

            // Act
            var result = resumeLogic.GetResume(0);

            // Assert
            Assert.False(result.Equals(resume));
        }
        [Fact]
        public void ChangeTimeTable()
        {
            // Arrange

            var mock = new Mock<IUnitOfWork>();
            Resume resume1 = new Resume();
            resume1.Id = 0;
            Resume resume = new Resume();
            resume.Position = "p";

            mock.Setup(a => a.Resumes.Get(It.IsAny<int>())).ReturnsAsync(resume);
            ResumeLogic resumeLogic = new ResumeLogic(mock.Object);

            // Act
            _ = resumeLogic.EditResume(0, resume);

            // Assert
            Assert.Equal(resume1.Position, resume.Position);
            mock.Verify(t => t.Resumes.Modify(resume.Id,resume));
        }
        [Fact]
        public async System.Threading.Tasks.Task RemoveResumeAsync()
        {
            // Arrange
            int id = 0;
            var mock = new Mock<IUnitOfWork>();
            ResumeLogic resumeLogic = new ResumeLogic(mock.Object);

            // Act
            await resumeLogic.DeleteResume(id).ConfigureAwait(false);

            // Assert
            mock.Verify(t => t.Resumes.Delete(id));
        }

    }

}
