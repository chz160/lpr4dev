using FluentAssertions;
using Lpr4dev.Tests.Resources;
using Xunit;

namespace Lpr4dev.Tests.Server.CertificateHelper
{
    public class CertificateHelperTests
    {
        [Fact]
        public void CanLoadCertificateAndKey()
        {
            var certificatePath = ResourceHelper.GetResourcePath("lpr4dev.crt");
            var certificateKeyPath = ResourceHelper.GetResourcePath("lpr4dev.key");

            var cert = Lpr4dev.Server.CertificateHelper.LoadCertificateWithKey(certificatePath, certificateKeyPath, "");

            cert.Should().NotBeNull();
            cert.HasPrivateKey.Should().BeTrue();
        }
    }
}