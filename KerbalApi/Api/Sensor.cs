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
  public partial class Sensor : TBase
  {
    private bool _active;
    private string _value;
    private double _powerUsage;
    private long _partId;

    public bool Active
    {
      get
      {
        return _active;
      }
      set
      {
        __isset.active = true;
        this._active = value;
      }
    }

    public string Value
    {
      get
      {
        return _value;
      }
      set
      {
        __isset.@value = true;
        this._value = value;
      }
    }

    public double PowerUsage
    {
      get
      {
        return _powerUsage;
      }
      set
      {
        __isset.powerUsage = true;
        this._powerUsage = value;
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
      public bool active;
      public bool @value;
      public bool powerUsage;
      public bool partId;
    }

    public Sensor() {
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
              Active = iprot.ReadBool();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 2:
            if (field.Type == TType.String) {
              Value = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 3:
            if (field.Type == TType.Double) {
              PowerUsage = iprot.ReadDouble();
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
      TStruct struc = new TStruct("Sensor");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (__isset.active) {
        field.Name = "active";
        field.Type = TType.Bool;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        oprot.WriteBool(Active);
        oprot.WriteFieldEnd();
      }
      if (Value != null && __isset.@value) {
        field.Name = "value";
        field.Type = TType.String;
        field.ID = 2;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(Value);
        oprot.WriteFieldEnd();
      }
      if (__isset.powerUsage) {
        field.Name = "powerUsage";
        field.Type = TType.Double;
        field.ID = 3;
        oprot.WriteFieldBegin(field);
        oprot.WriteDouble(PowerUsage);
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
      StringBuilder __sb = new StringBuilder("Sensor(");
      bool __first = true;
      if (__isset.active) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Active: ");
        __sb.Append(Active);
      }
      if (Value != null && __isset.@value) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Value: ");
        __sb.Append(Value);
      }
      if (__isset.powerUsage) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("PowerUsage: ");
        __sb.Append(PowerUsage);
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