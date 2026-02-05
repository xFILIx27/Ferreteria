pipeline {
    agent any
    stages {
        stage('Restore') {
            steps {
                bat "cd FerreteriaDiego"
                bat 'dotnet restore FerreteriaDiego'
            }
        }

        stage('Build') {
            steps {
                bat 'dotnet build FerreteriaDiego'
            }
        }

        stage('Test') {
            steps {
                
                bat 'dotnet test TestFactura'
            }
        }
    }
}
