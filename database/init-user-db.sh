#!/bin/bash

set -e

psql -v ON_ERROR_STOP=1 --username default --dbname LibreReview <<-EOSQL        
    GRANT ALL PRIVILEGES ON DATABASE LibreReview TO default;    
EOSQL