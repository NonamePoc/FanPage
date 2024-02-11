ø
oC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Exception\UserNotFoundException.cs
	namespace		 	
FanPage		
 
.		 

Exceptions		 
{

 
[ 
Serializable 
] 
public 

class !
UserNotFoundException &
:' (
ClientExceptionBase) <
{ 
public !
UserNotFoundException $
($ %
)% &
{ 	
} 	
public !
UserNotFoundException $
($ %
string% +
message, 3
)3 4
:5 6
base7 ;
(; <
message< C
)C D
{ 	
} 	
public !
UserNotFoundException $
($ %
string% +
message, 3
,3 4
	Exception5 >
inner? D
)D E
:F G
baseH L
(L M
messageM T
,T U
innerV [
)[ \
{ 	
} 	
	protected !
UserNotFoundException '
(' (
SerializationInfo 
info "
," #
StreamingContext 
context $
)$ %
:& '
base( ,
(, -
info- 1
,1 2
context3 :
): ;
{ 	
} 	
public   
override   
HttpStatusCode   &

StatusCode  ' 1
=>  2 4
HttpStatusCode  5 C
.  C D

BadRequest  D N
;  N O
}!! 
}"" ì
mC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Exception\UserDeleteException.cs
	namespace		 	
FanPage		
 
.		 

Exceptions		 
{

 
[ 
Serializable 
] 
public 

class 
UserDeleteException $
:% &
ClientExceptionBase' :
{ 
public 
UserDeleteException "
(" #
)# $
{ 	
} 	
public 
UserDeleteException "
(" #
string# )
message* 1
)1 2
:3 4
base5 9
(9 :
message: A
)A B
{ 	
} 	
public 
UserDeleteException "
(" #
string# )
message* 1
,1 2
	Exception3 <
inner= B
)B C
:D E
baseF J
(J K
messageK R
,R S
innerT Y
)Y Z
{ 	
} 	
	protected 
UserDeleteException %
(% &
SerializationInfo 
info "
," #
StreamingContext 
context $
)$ %
:& '
base( ,
(, -
info- 1
,1 2
context3 :
): ;
{ 	
} 	
public   
override   
HttpStatusCode   &

StatusCode  ' 1
=>  2 4
HttpStatusCode  5 C
.  C D

BadRequest  D N
;  N O
}!! 
}"" õ
mC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Exception\UserCreateException.cs
	namespace 	
FanPage
 
. 

Exceptions 
{ 
[ 
Serializable 
] 
public		 

class		 
UserCreateException		 $
:		% &
ClientExceptionBase		' :
{

 
public 
UserCreateException "
(" #
)# $
{ 	
} 	
public 
UserCreateException "
(" #
string# )
message* 1
)1 2
:3 4
base5 9
(9 :
message: A
)A B
{ 	
} 	
public 
UserCreateException "
(" #
string# )
message* 1
,1 2
	Exception3 <
inner= B
)B C
:D E
baseF J
(J K
messageK R
,R S
innerT Y
)Y Z
{ 	
} 	
	protected 
UserCreateException %
(% &
SerializationInfo 
info "
," #
StreamingContext 
context $
)$ %
:& '
base( ,
(, -
info- 1
,1 2
context3 :
): ;
{ 	
} 	
public 
override 
HttpStatusCode &

StatusCode' 1
=>2 4
HttpStatusCode5 C
.C D
InternalServerErrorD W
;W X
} 
}   
sC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Exception\UserAlreadyExistException.cs
	namespace		 	
FanPage		
 
.		 

Exceptions		 
{

 
[ 
Serializable 
] 
public 

class %
UserAlreadyExistException *
:+ ,
ClientExceptionBase- @
{ 
public %
UserAlreadyExistException (
(( )
)) *
{ 	
} 	
public %
UserAlreadyExistException (
(( )
string) /
message0 7
)7 8
:9 :
base; ?
(? @
message@ G
)G H
{ 	
} 	
public %
UserAlreadyExistException (
(( )
string) /
message0 7
,7 8
	Exception9 B
innerC H
)H I
:J K
baseL P
(P Q
messageQ X
,X Y
innerZ _
)_ `
{ 	
} 	
	protected %
UserAlreadyExistException +
(+ ,
SerializationInfo 
info "
," #
StreamingContext 
context $
)$ %
:& '
base( ,
(, -
info- 1
,1 2
context3 :
): ;
{ 	
} 	
public   
override   
HttpStatusCode   &

StatusCode  ' 1
=>  2 4
HttpStatusCode  5 C
.  C D

BadRequest  D N
;  N O
}!! 
}"" þ
pC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Exception\ResetPasswordException.cs
	namespace		 	
FanPage		
 
.		 

Exceptions		 
{

 
[ 
Serializable 
] 
public 

class "
ResetPasswordException '
:( )
ClientExceptionBase* =
{ 
public "
ResetPasswordException %
(% &
)& '
{ 	
} 	
public "
ResetPasswordException %
(% &
string& ,
message- 4
)4 5
:6 7
base8 <
(< =
message= D
)D E
{ 	
} 	
public "
ResetPasswordException %
(% &
string& ,
message- 4
,4 5
	Exception6 ?
inner@ E
)E F
:G H
baseI M
(M N
messageN U
,U V
innerW \
)\ ]
{ 	
} 	
	protected "
ResetPasswordException (
(( )
SerializationInfo 
info "
," #
StreamingContext 
context $
)$ %
:& '
base( ,
(, -
info- 1
,1 2
context3 :
): ;
{ 	
} 	
public   
override   
HttpStatusCode   &

StatusCode  ' 1
=>  2 4
HttpStatusCode  5 C
.  C D

BadRequest  D N
;  N O
}!! 
}"" Î
hC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Exception\LogInException.cs
	namespace 	
FanPage
 
. 

Exceptions 
{ 
[ 
Serializable 
] 
public 

class 
LogInException 
:  !
ClientExceptionBase" 5
{ 
public		 
LogInException		 
(		 
)		 
{

 	
} 	
public 
LogInException 
( 
string $
message% ,
), -
:. /
base0 4
(4 5
message5 <
)< =
{ 	
} 	
public 
LogInException 
( 
string $
message% ,
,, -
	Exception. 7
inner8 =
)= >
:? @
baseA E
(E F
messageF M
,M N
innerO T
)T U
{ 	
} 	
	protected 
LogInException  
(  !
SerializationInfo 
info "
," #
StreamingContext 
context $
)$ %
:& '
base( ,
(, -
info- 1
,1 2
context3 :
): ;
{ 	
} 	
public 
override 
HttpStatusCode &

StatusCode' 1
=>2 4
HttpStatusCode5 C
.C D

BadRequestD N
;N O
} 
} Š
rC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Exception\InvalidPasswordException.cs
	namespace		 	
FanPage		
 
.		 

Exceptions		 
{

 
[ 
Serializable 
] 
public 

class $
InvalidPasswordException )
:* +
ClientExceptionBase, ?
{ 
public $
InvalidPasswordException '
(' (
)( )
{ 	
} 	
public $
InvalidPasswordException '
(' (
string( .
message/ 6
)6 7
:8 9
base: >
(> ?
message? F
)F G
{ 	
} 	
public $
InvalidPasswordException '
(' (
string( .
message/ 6
,6 7
	Exception8 A
innerB G
)G H
:I J
baseK O
(O P
messageP W
,W X
innerY ^
)^ _
{ 	
} 	
	protected $
InvalidPasswordException *
(* +
SerializationInfo 
info "
," #
StreamingContext 
context $
)$ %
:& '
base( ,
(, -
info- 1
,1 2
context3 :
): ;
{ 	
} 	
public   
override   
HttpStatusCode   &

StatusCode  ' 1
=>  2 4
HttpStatusCode  5 C
.  C D

BadRequest  D N
;  N O
}!! 
}"" Ô
iC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Exception\FanficException.cs
	namespace 	
FanPage
 
. 

Exceptions 
{ 
[ 
Serializable 
] 
public 

class 
FanficException  
:! "
ClientExceptionBase# 6
{		 
public

 
FanficException

 
(

 
)

  
{ 	
} 	
public 
FanficException 
( 
string %
message& -
)- .
:/ 0
base1 5
(5 6
message6 =
)= >
{ 	
} 	
public 
FanficException 
( 
string %
message& -
,- .
	Exception/ 8
inner9 >
)> ?
:@ A
baseB F
(F G
messageG N
,N O
innerP U
)U V
{ 	
} 	
	protected 
FanficException !
(! "
SerializationInfo 
info "
," #
StreamingContext 
context $
)$ %
:& '
base( ,
(, -
info- 1
,1 2
context3 :
): ;
{ 	
} 	
public 
override 
HttpStatusCode &

StatusCode' 1
=>2 4
HttpStatusCode5 C
.C D

BadRequestD N
;N O
} 
} …
mC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Exception\ClientExceptionBase.cs
	namespace 	
FanPage
 
. 

Exceptions 
{ 
[ 
Serializable 
] 
public 

class 
ClientExceptionBase $
:% &
	Exception' 0
{		 
	protected

 
ClientExceptionBase

 %
(

% &
)

& '
{ 	
} 	
	protected 
ClientExceptionBase %
(% &
string& ,
message- 4
)4 5
:6 7
base8 <
(< =
message= D
)D E
{ 	
} 	
	protected 
ClientExceptionBase %
(% &
string& ,
message- 4
,4 5
	Exception6 ?
innerException@ N
)N O
:P Q
baseR V
(V W
messageW ^
,^ _
innerException` n
)n o
{ 	
} 	
	protected 
ClientExceptionBase %
(% &
SerializationInfo& 7
info8 <
,< =
StreamingContext> N
contextO V
)V W
:X Y
baseZ ^
(^ _
info_ c
,c d
contexte l
)l m
{ 	
} 	
public 
virtual 
HttpStatusCode %

StatusCode& 0
=>1 3
HttpStatusCode4 B
.B C
InternalServerErrorC V
;V W
} 
} µ
gC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Exception\ChatException.cs
	namespace 	
FanPage
 
. 

Exceptions 
; 
[ 
Serializable 
] 
public 
class 
ChatException 
: 
ClientExceptionBase 0
{ 
public		 

ChatException		 
(		 
)		 
{

 
} 
public 

ChatException 
( 
string 
message  '
)' (
:) *
base+ /
(/ 0
message0 7
)7 8
{ 
} 
public 

ChatException 
( 
string 
message  '
,' (
	Exception) 2
inner3 8
)8 9
:: ;
base< @
(@ A
messageA H
,H I
innerJ O
)O P
{ 
} 
	protected 
ChatException 
( 
SerializationInfo 
info 
, 
StreamingContext 
context  
)  !
:" #
base$ (
(( )
info) -
,- .
context/ 6
)6 7
{ 
} 
public 

override 
HttpStatusCode "

StatusCode# -
=>. 0
HttpStatusCode1 ?
.? @

BadRequest@ J
;J K
} „
qC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Exception\ChangePasswordException.cs
	namespace 	
FanPage
 
. 

Exceptions 
{ 
[ 
Serializable 
] 
public 

class #
ChangePasswordException (
:) *
ClientExceptionBase+ >
{ 
public		 #
ChangePasswordException		 &
(		& '
)		' (
{

 	
} 	
public #
ChangePasswordException &
(& '
string' -
message. 5
)5 6
:7 8
base9 =
(= >
message> E
)E F
{ 	
} 	
public #
ChangePasswordException &
(& '
string' -
message. 5
,5 6
	Exception7 @
innerA F
)F G
:H I
baseJ N
(N O
messageO V
,V W
innerX ]
)] ^
{ 	
} 	
	protected #
ChangePasswordException )
() *
SerializationInfo 
info "
," #
StreamingContext 
context $
)$ %
:& '
base( ,
(, -
info- 1
,1 2
context3 :
): ;
{ 	
} 	
public 
override 
HttpStatusCode &

StatusCode' 1
=>2 4
HttpStatusCode5 C
.C D

BadRequestD N
;N O
} 
} 