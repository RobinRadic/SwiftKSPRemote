rmdir KerbalApi\Api /S /Q
mkdir KerbalApi\Api

rmdir KerbalApiServer\Api /S /Q
mkdir KerbalApiServer\Api


thrift092.exe -v -r --gen csharp --out ..\SwiftKSPRemote -I KerbalApiServer\Definitions KerbalApi\Definitions\api.thrift

rmdir SwiftTest\Api /S /Q
mkdir SwiftTest\Api
xcopy KerbalApi\Api SwiftTest\Api /E
xcopy KerbalApiServer\Api SwiftTest\Api /E




rmdir KerbalMechApi\Api /S /Q
mkdir KerbalMechApi\Api

thrift092.exe -v -r --gen csharp --out ..\SwiftKSPRemote -I KerbalApiServer\Definitions -I KerbalApi\Definitions KerbalMechApi\Definitions\api.thrift


rmdir SwiftTest\MechApi /S /Q
mkdir SwiftTest\MechApi
xcopy KerbalMechApi\Api SwiftTest\MechApi /E

pause