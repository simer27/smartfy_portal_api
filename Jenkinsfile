pipeline {
    agent { label 'master' }
    stages {
        stage('Checkout') {
            steps {
				checkout scm
                echo "Hello World!"
            }
        }
    }
}