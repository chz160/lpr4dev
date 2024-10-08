﻿using FluentAssertions;
using Xunit;

namespace Lpr4dev.Tests.Server.SSCertGenerator
{
    public class CertificateTests
    {
        [Fact]
        public void CanGenerateSelfSignedCertificate()
        {
            var cert = Lpr4dev.Server.SSCertGenerator.CreateSelfSignedCertificate("localhost");
            cert.Should().NotBeNull();
        }
    }
}