using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Module
{
    public int LvlModul { get; set; }
    public Module(int _LvlModul)
    {
        LvlModul = _LvlModul;
    }
}
