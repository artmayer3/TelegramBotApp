docker run \
	--rm \
	-d \
	-p 8443:443 \
	-p 8080:80 \
	--name uspevaibot \
	-e ASPNETCORE_ENVIRONMENT=Production \
	-e ASPNETCORE_URLS="https://+;http://+" \
	-e ASPNETCORE_HTTPS_PORT=8443 \
	-e ASPNETCORE_Kestrel__Certificates__Default__Password="admin2020" \
	-e ASPNETCORE_Kestrel__Certificates__Default__Path=/https/aspnetapp.pfx \
	-v ~/ctfd/cert.pfx:/https/aspnetapp.pfx \
	uspevaibot
