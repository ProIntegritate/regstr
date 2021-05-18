# regstr
A strings replacement with built in RegExp support.

RegStr, a strings replacement with built in RegExp support. Written in 2021 by Glenn Larsson. Freeware and CC0.

*Syntax: RegStr filename.bin "regexp" (true)*

Last (true) is optional and fixes output if you're extracting domain names from certain files.

if you want to extract dns name strings from a PCAP of TLS negotiation packets, you would write:

*regstr tls.pcap "[a-zA-Z0-9-]{2,}\.[a-zA-Z]{2,}"*

and it would dump those strings on unique lines, but also including the adresses of CRL and OCSP providers so you would have to filter thatn for yourself.
