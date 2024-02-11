Ü
pC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.EmailService\Models\EmailRequest.cs
	namespace 	
FanPage
 
. 
EmailService 
. 
Models %
{ 
public		 

class		 
EmailRequest		 
{

 
public 
string 
? 
EmailTo 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
? 
Subject 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
? 
Html 
{ 
get !
;! "
set# &
;& '
}( )
} 
} ù
uC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.EmailService\Interfaces\IEmailService.cs
	namespace 	
FanPage
 
. 
EmailService 
. 

Interfaces )
{ 
public 

	interface 
IEmailService "
{ 
Task 
	SendAsync 
( 
EmailRequest #
emailRequest$ 0
)0 1
;1 2
}		 
}

 ž
yC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.EmailService\Implementations\EmailService.cs
	namespace 	
FanPage
 
. 
EmailService 
. 
Implementations .
{		 
public

 

class

 
EmailService

 
:

 
IEmailService

  -
{ 
private 
readonly 
SmtpConfiguration *
_configuration+ 9
;9 :
public 
EmailService 
( 
SmtpConfiguration -
configuration. ;
); <
{ 	
_configuration 
= 
configuration *
;* +
} 	
public 
async 
Task 
	SendAsync #
(# $
EmailRequest$ 0
request1 8
)8 9
{ 	
var 
email 
= 
new 
MimeMessage '
(' (
)( )
;) *
email 
. 
From 
. 
Add 
( 
MailboxAddress )
.) *
Parse* /
(/ 0
_configuration0 >
.> ?
	EmailFrom? H
)H I
)I J
;J K
email 
. 
To 
. 
Add 
( 
MailboxAddress '
.' (
Parse( -
(- .
request. 5
.5 6
EmailTo6 =
)= >
)> ?
;? @
email 
. 
Subject 
= 
request #
.# $
Subject$ +
;+ ,
email 
. 
Body 
= 
new 
TextPart %
(% &

TextFormat& 0
.0 1
Html1 5
)5 6
{7 8
Text9 =
=> ?
request@ G
.G H
HtmlH L
}M N
;N O
using 
var 
smtp 
= 
new  

SmtpClient! +
(+ ,
), -
;- .
await 
smtp 
. 
ConnectAsync #
(# $
_configuration$ 2
.2 3
Host3 7
,7 8
_configuration9 G
.G H
PortH L
)L M
;M N
await 
smtp 
. 
AuthenticateAsync (
(( )
_configuration) 7
.7 8
Login8 =
,= >
_configuration? M
.M N
PasswordN V
)V W
;W X
await 
smtp 
. 
	SendAsync  
(  !
email! &
)& '
;' (
await 
smtp 
. 
DisconnectAsync &
(& '
true' +
)+ ,
;, -
}   	
}!! 
}"" ø
|C:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.EmailService\Configuration\SmtpConfiguration.cs
	namespace 	
FanPage
 
. 
EmailService 
. 
Configuration ,
{ 
public 

class 
SmtpConfiguration "
{ 
public 
string 
Host 
{ 
get  
;  !
set" %
;% &
}' (
public 
int 
Port 
{ 
get 
; 
set "
;" #
}$ %
public		 
string		 
Login		 
{		 
get		 !
;		! "
set		# &
;		& '
}		( )
public 
string 
Password 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
	EmailFrom 
{  !
get" %
;% &
set' *
;* +
}, -
} 
} 