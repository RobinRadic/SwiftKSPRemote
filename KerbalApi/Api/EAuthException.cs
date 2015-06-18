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

  /// <summary>
  /// Thrown when authentication fails, this is thrown
  /// </summary>
  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class EAuthException : TException, TBase
  {
    private ErrorCode _code;
    private string _errorMessage;

    /// <summary>
    /// Detailed reason for the exception
    /// 
    /// <seealso cref="ErrorCode"/>
    /// </summary>
    public ErrorCode Code
    {
      get
      {
        return _code;
      }
      set
      {
        __isset.code = true;
        this._code = value;
      }
    }

    /// <summary>
    /// A message that describes the exception
    /// </summary>
    public string ErrorMessage
    {
      get
      {
        return _errorMessage;
      }
      set
      {
        __isset.errorMessage = true;
        this._errorMessage = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool code;
      public bool errorMessage;
    }

    public EAuthException() {
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
              Code = (ErrorCode)iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 2:
            if (field.Type == TType.String) {
              ErrorMessage = iprot.ReadString();
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
      TStruct struc = new TStruct("EAuthException");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (__isset.code) {
        field.Name = "code";
        field.Type = TType.I32;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32((int)Code);
        oprot.WriteFieldEnd();
      }
      if (ErrorMessage != null && __isset.errorMessage) {
        field.Name = "errorMessage";
        field.Type = TType.String;
        field.ID = 2;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(ErrorMessage);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder __sb = new StringBuilder("EAuthException(");
      bool __first = true;
      if (__isset.code) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Code: ");
        __sb.Append(Code);
      }
      if (ErrorMessage != null && __isset.errorMessage) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("ErrorMessage: ");
        __sb.Append(ErrorMessage);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
