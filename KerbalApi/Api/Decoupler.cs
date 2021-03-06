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

namespace KerbalApi.Api
{

  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class Decoupler : TBase
  {
    private bool _decoupled;
    private double _impulse;
    private long _partId;

    public bool Decoupled
    {
      get
      {
        return _decoupled;
      }
      set
      {
        __isset.decoupled = true;
        this._decoupled = value;
      }
    }

    public double Impulse
    {
      get
      {
        return _impulse;
      }
      set
      {
        __isset.impulse = true;
        this._impulse = value;
      }
    }

    public long PartId
    {
      get
      {
        return _partId;
      }
      set
      {
        __isset.partId = true;
        this._partId = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool decoupled;
      public bool impulse;
      public bool partId;
    }

    public Decoupler() {
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
            if (field.Type == TType.Bool) {
              Decoupled = iprot.ReadBool();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 2:
            if (field.Type == TType.Double) {
              Impulse = iprot.ReadDouble();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 10:
            if (field.Type == TType.I64) {
              PartId = iprot.ReadI64();
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
      TStruct struc = new TStruct("Decoupler");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (__isset.decoupled) {
        field.Name = "decoupled";
        field.Type = TType.Bool;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        oprot.WriteBool(Decoupled);
        oprot.WriteFieldEnd();
      }
      if (__isset.impulse) {
        field.Name = "impulse";
        field.Type = TType.Double;
        field.ID = 2;
        oprot.WriteFieldBegin(field);
        oprot.WriteDouble(Impulse);
        oprot.WriteFieldEnd();
      }
      if (__isset.partId) {
        field.Name = "partId";
        field.Type = TType.I64;
        field.ID = 10;
        oprot.WriteFieldBegin(field);
        oprot.WriteI64(PartId);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder __sb = new StringBuilder("Decoupler(");
      bool __first = true;
      if (__isset.decoupled) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Decoupled: ");
        __sb.Append(Decoupled);
      }
      if (__isset.impulse) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Impulse: ");
        __sb.Append(Impulse);
      }
      if (__isset.partId) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("PartId: ");
        __sb.Append(PartId);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
