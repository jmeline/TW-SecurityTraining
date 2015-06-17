# Makefile for latex

all:
	latexmk --pdf intro.tex

.PHONY:
	clean
clean:
	latexmk -c
