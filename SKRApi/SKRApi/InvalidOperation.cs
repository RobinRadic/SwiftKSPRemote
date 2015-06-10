/**
 * Autogenerated by Thrift Compiler (0.9.2)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Thrift;
using Thrift.Collections;
using System.Runtime.Serialization;
using Thrift.Protocol;
using Thrift.Transport;

namespace SKRApi
{

  /// <summary>
  /// Structs can also be exceptions, if they are nasty.
  /// </summary>
  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class InvalidOperation : TException, TBase
  {
    private int _what;
    private string _why;

    public int What
    {
      get
      {
        return _what;
      }
      set
      {
        __isset.what = true;
        this._what = value;
      }
    }

    public string Why
    {
      get
      {
        return _why;
      }
      set
      {
        __isset.why = true;
        this._why = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool what;
      public bool why;
    }

    public InvalidOperation() {
    }

    public void Read (TProtocol iprot)
    {
      TField field;
      iprot.ReadStructBegin();
      while (true)
      {
        field = iprot.ReadFieldBegin();
        if (field.Type == TType.Stop) { 
          break;
        }
        switch (field.ID)
        {
          case 1:
            if (field.Type == TType.I32) {
              What = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 2:
            if (field.Type == TType.String) {
              Why = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          default: 
            TProtocolUtil.Skip(iprot, field.Type);
            break;
        }
        iprot.ReadFieldEnd();
      }
      iprot.ReadStructEnd();
    }

    public void Write(TProtocol oprot) {
      TStruct struc = new TStruct("InvalidOperation");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (__isset.what) {
        field.Name = "what";
        field.Type = TType.I32;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(What);
        oprot.WriteFieldEnd();
      }
      if (Why != null && __isset.why) {
        field.Name = "why";
        field.Type = TType.String;
        field.ID = 2;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(Why);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder __sb = new StringBuilder("InvalidOperation(");
      bool __first = true;
      if (__isset.what) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("What: ");
        __sb.Append(What);
      }
      if (Why != null && __isset.why) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Why: ");
        __sb.Append(Why);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
