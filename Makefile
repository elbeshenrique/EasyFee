feepercentage-up:
	docker-compose up -d feepercentage

feepercentage-down:
	docker-compose stop feepercentage

calculatefee-up:
	docker-compose up -d calculatefee

calculatefee-down:
	docker-compose stop calculatefee

build:
	docker-compose build

up:
	docker-compose up -d

down:
	docker-compose down --remove-orphans

logs:
	docker-compose logs -f