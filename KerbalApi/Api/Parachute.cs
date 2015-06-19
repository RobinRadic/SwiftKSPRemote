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
  public partial class Parachute : TBase
  {
    private ParachuteState _state;
    private bool _deployed;
    private double _deployAltitude;
    private double _deployMinPressure;
    private long _partId;

    /// <summary>
    /// 
    /// <seealso cref="ParachuteState"/>
    /// </summary>
    public ParachuteState State
    {
      get
      {
        return _state;
      }
      set
      {
        __isset.state = true;
        this._state = value;
      }
    }

    public bool Deployed
    {
      get
      {
        return _deployed;
      }
      set
      {
        __isset.deployed = true;
        this._deployed = value;
      }
    }

    public double DeployAltitude
    {
      get
      {
        return _deployAltitude;
      }
      set
      {
        __isset.deployAltitude = true;
        this._deployAltitude = value;
      }
    }

    public double DeployMinPressure
    {
      get
      {
        return _deployMinPressure;
      }
      set
      {
        __isset.deployMinPressure = true;
        this._deployMinPressure = value;
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
      public bool state;
      public bool deployed;
      public bool deployAltitude;
      public bool deployMinPressure;
      public bool partId;
    }

    public Parachute() {
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
              State = (ParachuteState)iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 2:
            if (field.Type == TType.Bool) {
              Deployed = iprot.ReadBool();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 3:
            if (field.Type == TType.Double) {
              DeployAltitude = iprot.ReadDouble();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 4:
            if (field.Type == TType.Double) {
              DeployMinPressure = iprot.ReadDouble();
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
      TStruct struc = new TStruct("Parachute");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (__isset.state) {
        field.Name = "state";
        field.Type = TType.I32;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32((int)State);
        oprot.WriteFieldEnd();
      }
      if (__isset.deployed) {
        field.Name = "deployed";
        field.Type = TType.Bool;
        field.ID = 2;
        oprot.WriteFieldBegin(field);
        oprot.WriteBool(Deployed);
        oprot.WriteFieldEnd();
      }
      if (__isset.deployAltitude) {
        field.Name = "deployAltitude";
        field.Type = TType.Double;
        field.ID = 3;
        oprot.WriteFieldBegin(field);
        oprot.WriteDouble(DeployAltitude);
        oprot.WriteFieldEnd();
      }
      if (__isset.deployMinPressure) {
        field.Name = "deployMinPressure";
        field.Type = TType.Double;
        field.ID = 4;
        oprot.WriteFieldBegin(field);
        oprot.WriteDouble(DeployMinPressure);
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
      StringBuilder __sb = new StringBuilder("Parachute(");
      bool __first = true;
      if (__isset.state) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("State: ");
        __sb.Append(State);
      }
      if (__isset.deployed) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Deployed: ");
        __sb.Append(Deployed);
      }
      if (__isset.deployAltitude) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("DeployAltitude: ");
        __sb.Append(DeployAltitude);
      }
      if (__isset.deployMinPressure) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("DeployMinPressure: ");
        __sb.Append(DeployMinPressure);
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