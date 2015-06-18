rmdir KerbalApi\Api /S /Q
mkdir KerbalApi\Api
thrift092.exe --gen csharp --out ..\SwiftKSPRemote KerbalApi\KerbalApi.thrift
pause