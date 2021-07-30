using System;
using System.Collections.Generic;

namespace Wiederholung
{
    class Datentypen
    {
        // Ganze zahlen

        int GanzeZahl4ByteMitVorzeichen; // -2,14 Milliarden bis +2,14 Milliarden, häufigster Datentyp
        uint GanzeZahl4ByteOhneVorzeichen; // 0 bis +4,29 Milliarden  "unsigned integer"

        short GanzeZahl2ByteMitVorzeichen; // -32 Tausend bis +32 Tausend
        ushort GanzeZahl2ByteOhneVorzeichen; // 0 bis 65535 , beliebt bei Netzwerk

        byte GanzeZahl1ByteOhneVorzeichen; // 0 bis 255
        sbyte GanzeZahl1ByteMitVorzeichen; // -128 bis +127

    }
}
