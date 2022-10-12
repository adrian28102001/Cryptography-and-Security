using Symmetric_Cryptography.BlockCipher.DSE;
using Symmetric_Cryptography.StreamCipher.RC4;

namespace Symmetric_Cryptography.Control;

public class ControlCipher : IControlCiphers
{
    private readonly IRC4 _rc4;
    private readonly IDSE _dse;

    public ControlCipher(IRC4 rc4, IDSE dse)
    {
        _rc4 = rc4;
        _dse = dse;
    }

    public void RunCiphers()
    {
        _rc4.RunCipher();
        _dse.RunCipher();
    }
}