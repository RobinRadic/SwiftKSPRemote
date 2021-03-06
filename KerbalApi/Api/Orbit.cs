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
  public partial class Orbit : TBase
  {
    private double _apoasis;
    private double _periapsis;
    private double _apoasisAltitude;
    private double _periapsisAltitude;
    private double _semiMajorAxis;
    private double _semiMinorAxis;
    private double _radius;
    private double _speed;
    private double _period;
    private double _timeToApoasis;
    private double _timeToPeriapsis;
    private double _eccentricity;
    private double _inclination;
    private double _longitudeOfAscendingNode;
    private double _argumentOfPeriapsis;
    private double _meanAnomalyAtEpoch;
    private double _epoch;
    private double _meanAnomaly;
    private double _eccentricAnomaly;

    public double Apoasis
    {
      get
      {
        return _apoasis;
      }
      set
      {
        __isset.apoasis = true;
        this._apoasis = value;
      }
    }

    public double Periapsis
    {
      get
      {
        return _periapsis;
      }
      set
      {
        __isset.periapsis = true;
        this._periapsis = value;
      }
    }

    public double ApoasisAltitude
    {
      get
      {
        return _apoasisAltitude;
      }
      set
      {
        __isset.apoasisAltitude = true;
        this._apoasisAltitude = value;
      }
    }

    public double PeriapsisAltitude
    {
      get
      {
        return _periapsisAltitude;
      }
      set
      {
        __isset.periapsisAltitude = true;
        this._periapsisAltitude = value;
      }
    }

    public double SemiMajorAxis
    {
      get
      {
        return _semiMajorAxis;
      }
      set
      {
        __isset.semiMajorAxis = true;
        this._semiMajorAxis = value;
      }
    }

    public double SemiMinorAxis
    {
      get
      {
        return _semiMinorAxis;
      }
      set
      {
        __isset.semiMinorAxis = true;
        this._semiMinorAxis = value;
      }
    }

    public double Radius
    {
      get
      {
        return _radius;
      }
      set
      {
        __isset.radius = true;
        this._radius = value;
      }
    }

    public double Speed
    {
      get
      {
        return _speed;
      }
      set
      {
        __isset.speed = true;
        this._speed = value;
      }
    }

    public double Period
    {
      get
      {
        return _period;
      }
      set
      {
        __isset.period = true;
        this._period = value;
      }
    }

    public double TimeToApoasis
    {
      get
      {
        return _timeToApoasis;
      }
      set
      {
        __isset.timeToApoasis = true;
        this._timeToApoasis = value;
      }
    }

    public double TimeToPeriapsis
    {
      get
      {
        return _timeToPeriapsis;
      }
      set
      {
        __isset.timeToPeriapsis = true;
        this._timeToPeriapsis = value;
      }
    }

    public double Eccentricity
    {
      get
      {
        return _eccentricity;
      }
      set
      {
        __isset.eccentricity = true;
        this._eccentricity = value;
      }
    }

    public double Inclination
    {
      get
      {
        return _inclination;
      }
      set
      {
        __isset.inclination = true;
        this._inclination = value;
      }
    }

    public double LongitudeOfAscendingNode
    {
      get
      {
        return _longitudeOfAscendingNode;
      }
      set
      {
        __isset.longitudeOfAscendingNode = true;
        this._longitudeOfAscendingNode = value;
      }
    }

    public double ArgumentOfPeriapsis
    {
      get
      {
        return _argumentOfPeriapsis;
      }
      set
      {
        __isset.argumentOfPeriapsis = true;
        this._argumentOfPeriapsis = value;
      }
    }

    public double MeanAnomalyAtEpoch
    {
      get
      {
        return _meanAnomalyAtEpoch;
      }
      set
      {
        __isset.meanAnomalyAtEpoch = true;
        this._meanAnomalyAtEpoch = value;
      }
    }

    public double Epoch
    {
      get
      {
        return _epoch;
      }
      set
      {
        __isset.epoch = true;
        this._epoch = value;
      }
    }

    public double MeanAnomaly
    {
      get
      {
        return _meanAnomaly;
      }
      set
      {
        __isset.meanAnomaly = true;
        this._meanAnomaly = value;
      }
    }

    public double EccentricAnomaly
    {
      get
      {
        return _eccentricAnomaly;
      }
      set
      {
        __isset.eccentricAnomaly = true;
        this._eccentricAnomaly = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool apoasis;
      public bool periapsis;
      public bool apoasisAltitude;
      public bool periapsisAltitude;
      public bool semiMajorAxis;
      public bool semiMinorAxis;
      public bool radius;
      public bool speed;
      public bool period;
      public bool timeToApoasis;
      public bool timeToPeriapsis;
      public bool eccentricity;
      public bool inclination;
      public bool longitudeOfAscendingNode;
      public bool argumentOfPeriapsis;
      public bool meanAnomalyAtEpoch;
      public bool epoch;
      public bool meanAnomaly;
      public bool eccentricAnomaly;
    }

    public Orbit() {
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
          case 2:
            if (field.Type == TType.Double) {
              Apoasis = iprot.ReadDouble();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 3:
            if (field.Type == TType.Double) {
              Periapsis = iprot.ReadDouble();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 4:
            if (field.Type == TType.Double) {
              ApoasisAltitude = iprot.ReadDouble();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 5:
            if (field.Type == TType.Double) {
              PeriapsisAltitude = iprot.ReadDouble();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 7:
            if (field.Type == TType.Double) {
              SemiMajorAxis = iprot.ReadDouble();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 8:
            if (field.Type == TType.Double) {
              SemiMinorAxis = iprot.ReadDouble();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 9:
            if (field.Type == TType.Double) {
              Radius = iprot.ReadDouble();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 10:
            if (field.Type == TType.Double) {
              Speed = iprot.ReadDouble();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 11:
            if (field.Type == TType.Double) {
              Period = iprot.ReadDouble();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 12:
            if (field.Type == TType.Double) {
              TimeToApoasis = iprot.ReadDouble();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 13:
            if (field.Type == TType.Double) {
              TimeToPeriapsis = iprot.ReadDouble();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 14:
            if (field.Type == TType.Double) {
              Eccentricity = iprot.ReadDouble();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 15:
            if (field.Type == TType.Double) {
              Inclination = iprot.ReadDouble();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 16:
            if (field.Type == TType.Double) {
              LongitudeOfAscendingNode = iprot.ReadDouble();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 17:
            if (field.Type == TType.Double) {
              ArgumentOfPeriapsis = iprot.ReadDouble();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 18:
            if (field.Type == TType.Double) {
              MeanAnomalyAtEpoch = iprot.ReadDouble();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 19:
            if (field.Type == TType.Double) {
              Epoch = iprot.ReadDouble();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 20:
            if (field.Type == TType.Double) {
              MeanAnomaly = iprot.ReadDouble();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 21:
            if (field.Type == TType.Double) {
              EccentricAnomaly = iprot.ReadDouble();
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
      TStruct struc = new TStruct("Orbit");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (__isset.apoasis) {
        field.Name = "apoasis";
        field.Type = TType.Double;
        field.ID = 2;
        oprot.WriteFieldBegin(field);
        oprot.WriteDouble(Apoasis);
        oprot.WriteFieldEnd();
      }
      if (__isset.periapsis) {
        field.Name = "periapsis";
        field.Type = TType.Double;
        field.ID = 3;
        oprot.WriteFieldBegin(field);
        oprot.WriteDouble(Periapsis);
        oprot.WriteFieldEnd();
      }
      if (__isset.apoasisAltitude) {
        field.Name = "apoasisAltitude";
        field.Type = TType.Double;
        field.ID = 4;
        oprot.WriteFieldBegin(field);
        oprot.WriteDouble(ApoasisAltitude);
        oprot.WriteFieldEnd();
      }
      if (__isset.periapsisAltitude) {
        field.Name = "periapsisAltitude";
        field.Type = TType.Double;
        field.ID = 5;
        oprot.WriteFieldBegin(field);
        oprot.WriteDouble(PeriapsisAltitude);
        oprot.WriteFieldEnd();
      }
      if (__isset.semiMajorAxis) {
        field.Name = "semiMajorAxis";
        field.Type = TType.Double;
        field.ID = 7;
        oprot.WriteFieldBegin(field);
        oprot.WriteDouble(SemiMajorAxis);
        oprot.WriteFieldEnd();
      }
      if (__isset.semiMinorAxis) {
        field.Name = "semiMinorAxis";
        field.Type = TType.Double;
        field.ID = 8;
        oprot.WriteFieldBegin(field);
        oprot.WriteDouble(SemiMinorAxis);
        oprot.WriteFieldEnd();
      }
      if (__isset.radius) {
        field.Name = "radius";
        field.Type = TType.Double;
        field.ID = 9;
        oprot.WriteFieldBegin(field);
        oprot.WriteDouble(Radius);
        oprot.WriteFieldEnd();
      }
      if (__isset.speed) {
        field.Name = "speed";
        field.Type = TType.Double;
        field.ID = 10;
        oprot.WriteFieldBegin(field);
        oprot.WriteDouble(Speed);
        oprot.WriteFieldEnd();
      }
      if (__isset.period) {
        field.Name = "period";
        field.Type = TType.Double;
        field.ID = 11;
        oprot.WriteFieldBegin(field);
        oprot.WriteDouble(Period);
        oprot.WriteFieldEnd();
      }
      if (__isset.timeToApoasis) {
        field.Name = "timeToApoasis";
        field.Type = TType.Double;
        field.ID = 12;
        oprot.WriteFieldBegin(field);
        oprot.WriteDouble(TimeToApoasis);
        oprot.WriteFieldEnd();
      }
      if (__isset.timeToPeriapsis) {
        field.Name = "timeToPeriapsis";
        field.Type = TType.Double;
        field.ID = 13;
        oprot.WriteFieldBegin(field);
        oprot.WriteDouble(TimeToPeriapsis);
        oprot.WriteFieldEnd();
      }
      if (__isset.eccentricity) {
        field.Name = "eccentricity";
        field.Type = TType.Double;
        field.ID = 14;
        oprot.WriteFieldBegin(field);
        oprot.WriteDouble(Eccentricity);
        oprot.WriteFieldEnd();
      }
      if (__isset.inclination) {
        field.Name = "inclination";
        field.Type = TType.Double;
        field.ID = 15;
        oprot.WriteFieldBegin(field);
        oprot.WriteDouble(Inclination);
        oprot.WriteFieldEnd();
      }
      if (__isset.longitudeOfAscendingNode) {
        field.Name = "longitudeOfAscendingNode";
        field.Type = TType.Double;
        field.ID = 16;
        oprot.WriteFieldBegin(field);
        oprot.WriteDouble(LongitudeOfAscendingNode);
        oprot.WriteFieldEnd();
      }
      if (__isset.argumentOfPeriapsis) {
        field.Name = "argumentOfPeriapsis";
        field.Type = TType.Double;
        field.ID = 17;
        oprot.WriteFieldBegin(field);
        oprot.WriteDouble(ArgumentOfPeriapsis);
        oprot.WriteFieldEnd();
      }
      if (__isset.meanAnomalyAtEpoch) {
        field.Name = "meanAnomalyAtEpoch";
        field.Type = TType.Double;
        field.ID = 18;
        oprot.WriteFieldBegin(field);
        oprot.WriteDouble(MeanAnomalyAtEpoch);
        oprot.WriteFieldEnd();
      }
      if (__isset.epoch) {
        field.Name = "epoch";
        field.Type = TType.Double;
        field.ID = 19;
        oprot.WriteFieldBegin(field);
        oprot.WriteDouble(Epoch);
        oprot.WriteFieldEnd();
      }
      if (__isset.meanAnomaly) {
        field.Name = "meanAnomaly";
        field.Type = TType.Double;
        field.ID = 20;
        oprot.WriteFieldBegin(field);
        oprot.WriteDouble(MeanAnomaly);
        oprot.WriteFieldEnd();
      }
      if (__isset.eccentricAnomaly) {
        field.Name = "eccentricAnomaly";
        field.Type = TType.Double;
        field.ID = 21;
        oprot.WriteFieldBegin(field);
        oprot.WriteDouble(EccentricAnomaly);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder __sb = new StringBuilder("Orbit(");
      bool __first = true;
      if (__isset.apoasis) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Apoasis: ");
        __sb.Append(Apoasis);
      }
      if (__isset.periapsis) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Periapsis: ");
        __sb.Append(Periapsis);
      }
      if (__isset.apoasisAltitude) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("ApoasisAltitude: ");
        __sb.Append(ApoasisAltitude);
      }
      if (__isset.periapsisAltitude) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("PeriapsisAltitude: ");
        __sb.Append(PeriapsisAltitude);
      }
      if (__isset.semiMajorAxis) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("SemiMajorAxis: ");
        __sb.Append(SemiMajorAxis);
      }
      if (__isset.semiMinorAxis) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("SemiMinorAxis: ");
        __sb.Append(SemiMinorAxis);
      }
      if (__isset.radius) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Radius: ");
        __sb.Append(Radius);
      }
      if (__isset.speed) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Speed: ");
        __sb.Append(Speed);
      }
      if (__isset.period) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Period: ");
        __sb.Append(Period);
      }
      if (__isset.timeToApoasis) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("TimeToApoasis: ");
        __sb.Append(TimeToApoasis);
      }
      if (__isset.timeToPeriapsis) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("TimeToPeriapsis: ");
        __sb.Append(TimeToPeriapsis);
      }
      if (__isset.eccentricity) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Eccentricity: ");
        __sb.Append(Eccentricity);
      }
      if (__isset.inclination) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Inclination: ");
        __sb.Append(Inclination);
      }
      if (__isset.longitudeOfAscendingNode) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("LongitudeOfAscendingNode: ");
        __sb.Append(LongitudeOfAscendingNode);
      }
      if (__isset.argumentOfPeriapsis) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("ArgumentOfPeriapsis: ");
        __sb.Append(ArgumentOfPeriapsis);
      }
      if (__isset.meanAnomalyAtEpoch) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("MeanAnomalyAtEpoch: ");
        __sb.Append(MeanAnomalyAtEpoch);
      }
      if (__isset.epoch) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Epoch: ");
        __sb.Append(Epoch);
      }
      if (__isset.meanAnomaly) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("MeanAnomaly: ");
        __sb.Append(MeanAnomaly);
      }
      if (__isset.eccentricAnomaly) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("EccentricAnomaly: ");
        __sb.Append(EccentricAnomaly);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
