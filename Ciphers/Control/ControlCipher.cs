using Lab1.BlockCipher.DSE;
using Lab1.StreamCipher.RC4;

namespace Lab1.Control;

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