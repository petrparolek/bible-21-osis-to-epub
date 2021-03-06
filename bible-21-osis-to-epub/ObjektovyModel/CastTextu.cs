﻿using System.Collections.Generic;

namespace BibleDoEpubu.ObjektovyModel
{
  internal class CastTextu
  {
    #region Vlastnosti

    public List<CastTextu> Potomci
    {
      get;
      set;
    } = new List<CastTextu>();

    public CastTextu Rodic
    {
      get;
      set;
    }

    public string TextovaData
    {
      get;
      set;
    }

    #endregion

    #region Metody

    public void PridatPotomka(CastTextu potomek)
    {
      Potomci.Remove(potomek);
      Potomci.Add(potomek);

      potomek.Rodic = this;
    }

    public List<T> ZiskatRekurzivniPotomky<T>() where T : CastTextu
    {
      List<T> potomci = new List<T>();

      if (this is T)
      {
        potomci.Add(this as T);
      }

      foreach (CastTextu potomek in Potomci)
      {
        potomci.AddRange(potomek.ZiskatRekurzivniPotomky<T>());
      }

      return potomci;
    }

    public void OdstranitPotomka(CastTextu potomek)
    {
      Potomci.Remove(potomek);
      potomek.Rodic = null;
    }

    #endregion
  }
}