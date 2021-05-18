# regstr
A strings replacement with built in RegExp support.

RegStr, a strings replacement with built in RegExp support. Written in 2021 by Glenn Larsson. Freeware and CC0.

*Syntax: RegStr filename.bin "regexp" (true)*

Last (true) is optional and fixes output if you're extracting domain names from certain files.

if you want to extract dns name strings from a PCAP of TLS negotiation packets, you would write:

*regstr tls.pcap "[a-zA-Z0-9-]{2,}\.[a-zA-Z]{2,}"*

and it would dump those strings on unique lines, but also including the adresses of CRL and OCSP providers so you would have to filter thatn for yourself.

Examples of output:

<u>These are the domain names you're looking for:</u>
cpanel.foobar.com
*.foobar.com
*.api.foobar.com

<u>OCSP/CRL sites: (maybe what you're not looking for)</u>
r3.o.lencr.org
r3.i.lencr.org
cps.letsencrypt.org
ocsp.godaddy.com
ocsp.sectigo.com
certificates.godaddy.com
dvcasha2.ocsp-certum.com
certs.starfieldtech.com
crl3.digicert.com
crl4.digicert.com

<u>CRT/CRL files also dumped (also known as junk output)</u>
SectigoRSADomainValidationSecureServerCA.crt
cPanelIncCertificationAuthority.crt
cPanelIncCertificationAuthority.crl
CloudflareIncECCCA-3.crl
ThawteRSACA2018.crl
