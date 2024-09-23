# LogKeep

A small application that manages logs in a flexible manner.

# API

This repository contains the API source code of LogKeep. This project is under construction.

# Main considerations

This project uses MongoDb to store logs. There's a "Structures" collection that stores the name of different log strucutures along with its fields definition, which consists of a name and a datatype. Then there will be an "AuditLogs" collection that will store logs corresponding to a structure. Doing this, an application consuming this API will be able to correctly parse any stored log.
