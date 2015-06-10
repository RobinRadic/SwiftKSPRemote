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

  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class Vector3d : TBase
  {
    private double _x;
    private double _y;
    private double _z;
    private Vector3d _back;
    private Vector3d _down;
    private Vector3d _forward;
    private Vector3d _left;
    private double _magnitude;
    private Vector3d _normalized;
    private Vector3d _one;
    private Vector3d _right;
    private double _sqrMagnitude;
    private Vector3d _up;
    private Vector3d _zero;
    private string _asString;

    public double X
    {
      get
      {
        return _x;
      }
      set
      {
        __isset.x = true;
        this._x = value;
      }
    }

    public double Y
    {
      get
      {
        return _y;
      }
      set
      {
        __isset.y = true;
        this._y = value;
      }
    }

    public double Z
    {
      get
      {
        return _z;
      }
      set
      {
        __isset.z = true;
        this._z = value;
      }
    }

    public Vector3d Back
    {
      get
      {
        return _back;
      }
      set
      {
        __isset.back = true;
        this._back = value;
      }
    }

    public Vector3d Down
    {
      get
      {
        return _down;
      }
      set
      {
        __isset.down = true;
        this._down = value;
      }
    }

    public Vector3d Forward
    {
      get
      {
        return _forward;
      }
      set
      {
        __isset.forward = true;
        this._forward = value;
      }
    }

    public Vector3d Left
    {
      get
      {
        return _left;
      }
      set
      {
        __isset.left = true;
        this._left = value;
      }
    }

    public double Magnitude
    {
      get
      {
        return _magnitude;
      }
      set
      {
        __isset.magnitude = true;
        this._magnitude = value;
      }
    }

    public Vector3d Normalized
    {
      get
      {
        return _normalized;
      }
      set
      {
        __isset.normalized = true;
        this._normalized = value;
      }
    }

    public Vector3d One
    {
      get
      {
        return _one;
      }
      set
      {
        __isset.one = true;
        this._one = value;
      }
    }

    public Vector3d Right
    {
      get
      {
        return _right;
      }
      set
      {
        __isset.right = true;
        this._right = value;
      }
    }

    public double SqrMagnitude
    {
      get
      {
        return _sqrMagnitude;
      }
      set
      {
        __isset.sqrMagnitude = true;
        this._sqrMagnitude = value;
      }
    }

    public Vector3d Up
    {
      get
      {
        return _up;
      }
      set
      {
        __isset.up = true;
        this._up = value;
      }
    }

    public Vector3d Zero
    {
      get
      {
        return _zero;
      }
      set
      {
        __isset.zero = true;
        this._zero = value;
      }
    }

    public string AsString
    {
      get
      {
        return _asString;
      }
      set
      {
        __isset.asString = true;
        this._asString = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool x;
      public bool y;
      public bool z;
      public bool back;
      public bool down;
      public bool forward;
      public bool left;
      public bool magnitude;
      public bool normalized;
      public bool one;
      public bool right;
      public bool sqrMagnitude;
      public bool up;
      public bool zero;
      public bool asString;
    }

    public Vector3d() {
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
            if (field.Type == TType.Double) {
              X = iprot.ReadDouble();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 2:
            if (field.Type == TType.Double) {
              Y = iprot.ReadDouble();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 3:
            if (field.Type == TType.Double) {
              Z = iprot.ReadDouble();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 4:
            if (field.Type == TType.Struct) {
              Back = new Vector3d();
              Back.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 5:
            if (field.Type == TType.Struct) {
              Down = new Vector3d();
              Down.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 6:
            if (field.Type == TType.Struct) {
              Forward = new Vector3d();
              Forward.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 7:
            if (field.Type == TType.Struct) {
              Left = new Vector3d();
              Left.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 8:
            if (field.Type == TType.Double) {
              Magnitude = iprot.ReadDouble();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 9:
            if (field.Type == TType.Struct) {
              Normalized = new Vector3d();
              Normalized.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 10:
            if (field.Type == TType.Struct) {
              One = new Vector3d();
              One.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 11:
            if (field.Type == TType.Struct) {
              Right = new Vector3d();
              Right.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 12:
            if (field.Type == TType.Double) {
              SqrMagnitude = iprot.ReadDouble();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 13:
            if (field.Type == TType.Struct) {
              Up = new Vector3d();
              Up.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 14:
            if (field.Type == TType.Struct) {
              Zero = new Vector3d();
              Zero.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 15:
            if (field.Type == TType.String) {
              AsString = iprot.ReadString();
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
      TStruct struc = new TStruct("Vector3d");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (__isset.x) {
        field.Name = "x";
        field.Type = TType.Double;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        oprot.WriteDouble(X);
        oprot.WriteFieldEnd();
      }
      if (__isset.y) {
        field.Name = "y";
        field.Type = TType.Double;
        field.ID = 2;
        oprot.WriteFieldBegin(field);
        oprot.WriteDouble(Y);
        oprot.WriteFieldEnd();
      }
      if (__isset.z) {
        field.Name = "z";
        field.Type = TType.Double;
        field.ID = 3;
        oprot.WriteFieldBegin(field);
        oprot.WriteDouble(Z);
        oprot.WriteFieldEnd();
      }
      if (Back != null && __isset.back) {
        field.Name = "back";
        field.Type = TType.Struct;
        field.ID = 4;
        oprot.WriteFieldBegin(field);
        Back.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (Down != null && __isset.down) {
        field.Name = "down";
        field.Type = TType.Struct;
        field.ID = 5;
        oprot.WriteFieldBegin(field);
        Down.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (Forward != null && __isset.forward) {
        field.Name = "forward";
        field.Type = TType.Struct;
        field.ID = 6;
        oprot.WriteFieldBegin(field);
        Forward.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (Left != null && __isset.left) {
        field.Name = "left";
        field.Type = TType.Struct;
        field.ID = 7;
        oprot.WriteFieldBegin(field);
        Left.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (__isset.magnitude) {
        field.Name = "magnitude";
        field.Type = TType.Double;
        field.ID = 8;
        oprot.WriteFieldBegin(field);
        oprot.WriteDouble(Magnitude);
        oprot.WriteFieldEnd();
      }
      if (Normalized != null && __isset.normalized) {
        field.Name = "normalized";
        field.Type = TType.Struct;
        field.ID = 9;
        oprot.WriteFieldBegin(field);
        Normalized.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (One != null && __isset.one) {
        field.Name = "one";
        field.Type = TType.Struct;
        field.ID = 10;
        oprot.WriteFieldBegin(field);
        One.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (Right != null && __isset.right) {
        field.Name = "right";
        field.Type = TType.Struct;
        field.ID = 11;
        oprot.WriteFieldBegin(field);
        Right.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (__isset.sqrMagnitude) {
        field.Name = "sqrMagnitude";
        field.Type = TType.Double;
        field.ID = 12;
        oprot.WriteFieldBegin(field);
        oprot.WriteDouble(SqrMagnitude);
        oprot.WriteFieldEnd();
      }
      if (Up != null && __isset.up) {
        field.Name = "up";
        field.Type = TType.Struct;
        field.ID = 13;
        oprot.WriteFieldBegin(field);
        Up.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (Zero != null && __isset.zero) {
        field.Name = "zero";
        field.Type = TType.Struct;
        field.ID = 14;
        oprot.WriteFieldBegin(field);
        Zero.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (AsString != null && __isset.asString) {
        field.Name = "asString";
        field.Type = TType.String;
        field.ID = 15;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(AsString);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder __sb = new StringBuilder("Vector3d(");
      bool __first = true;
      if (__isset.x) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("X: ");
        __sb.Append(X);
      }
      if (__isset.y) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Y: ");
        __sb.Append(Y);
      }
      if (__isset.z) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Z: ");
        __sb.Append(Z);
      }
      if (Back != null && __isset.back) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Back: ");
        __sb.Append(Back);
      }
      if (Down != null && __isset.down) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Down: ");
        __sb.Append(Down);
      }
      if (Forward != null && __isset.forward) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Forward: ");
        __sb.Append(Forward);
      }
      if (Left != null && __isset.left) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Left: ");
        __sb.Append(Left);
      }
      if (__isset.magnitude) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Magnitude: ");
        __sb.Append(Magnitude);
      }
      if (Normalized != null && __isset.normalized) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Normalized: ");
        __sb.Append(Normalized);
      }
      if (One != null && __isset.one) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("One: ");
        __sb.Append(One);
      }
      if (Right != null && __isset.right) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Right: ");
        __sb.Append(Right);
      }
      if (__isset.sqrMagnitude) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("SqrMagnitude: ");
        __sb.Append(SqrMagnitude);
      }
      if (Up != null && __isset.up) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Up: ");
        __sb.Append(Up);
      }
      if (Zero != null && __isset.zero) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Zero: ");
        __sb.Append(Zero);
      }
      if (AsString != null && __isset.asString) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("AsString: ");
        __sb.Append(AsString);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}