pipeline {
    agent any
    stages {
        stage('Restore') {
            steps {
                bat "cd FerreteriaDiego"
                bat 'dotnet restore '
            }
        }

        stage('Build') {
            steps {
                bat 'dotnet build '
            }
        }

        stage('Test') {
            steps {
                bat "cd ..\\TestFactura"
                bat 'dotnet test '
            }
        }
    }
}
