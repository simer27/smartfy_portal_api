pipeline {
    agent { label 'master' }
    stages {
        stage('Checkout') {
			checkout scm
            steps {
                echo "Hello World!"
            }
        }
    }
}