rmdir SKRApi\SKRApi /S /Q
mkdir SKRApi\SKRApi
rmdir SwiftKSPRemote\Api /S /Q
mkdir SwiftKSPRemote\Api
thrift092.exe --gen csharp --out SKRApi SKRApi\SKRApi.thrift
thrift092.exe --gen csharp --out ..\SwiftKSPRemote SwiftKSPRemote\SwiftKSPRemoteApi.thrift
pause