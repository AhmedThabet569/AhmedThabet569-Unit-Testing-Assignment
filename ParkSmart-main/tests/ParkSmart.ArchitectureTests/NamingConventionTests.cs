using NetArchTest.Rules;
using ParkSmart.Domain;
using ParkSmart.Domain.Interface;
using ParkSmart.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkSmart.ArchitectureTests
{
    public class NamingConventionTests
    {
        [Fact]
        public void Interfaces_Should_Start_With_I()
        {

            var result = Types.InAssembly(typeof(IRefrence).Assembly)
             .That()
             .AreInterfaces()
            .And()
             .ResideInNamespace("ParkSmart.Domain.Interface")
             .Should()
             .HaveNameStartingWith("I")
             .GetResult();

            Assert.True(result.IsSuccessful);
        }

        //[Fact]
        //public void Classes_Should_End_With_Tests()
        //{
        //    var result = Types.InAssembly(typeof(ParkSmart.ArchitectureTests.NamingConventionTests).Assembly)
        //     .That()
        //     .AreClasses()
        //     .Should()
        //     .HaveNameEndingWith("Tests")
        //     .GetResult();
        //    Assert.True(result.IsSuccessful);
        //}
        [Fact]
        public  void Services_Should_End_With_Service()
        {
            var result = Types.InAssembly(typeof(DomainService).Assembly)
             .That()
             .ResideInNamespace("ParkSmart.Domain.Services")
             .Should()
             .HaveNameEndingWith("Service")
             .GetResult();
            Assert.True(result.IsSuccessful);
        }
    }
}
