docker run \
	--rm \
	-d \
	-p 8443:443 \
	-p 8080:80 \
	--name botName \
	-e ASPNETCORE_ENVIRONMENT=Production \
	-e ASPNETCORE_URLS="https://+;http://+" \
	-e ASPNETCORE_HTTPS_PORT=8443 \
	-e ASPNETCORE_Kestrel__Certificates__Default__Password="" \
	-e ASPNETCORE_Kestrel__Certificates__Default__Path=/https/aspnetapp.pfx \
	-v ~/folder/cert.pfx:/https/aspnetapp.pfx \
	botName
