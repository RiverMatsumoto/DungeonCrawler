using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommand
{
    public void execute();
    public void undo();
}
