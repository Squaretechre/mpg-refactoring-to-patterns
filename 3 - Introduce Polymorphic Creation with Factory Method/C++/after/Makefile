GOOGLE_TEST_LIB = gtest
GOOGLE_TEST_INCLUDE = /usr/local/include
GOOGLE_TEST_LIB_DIR = /usr/local/lib

CC=g++
CFLAGS=-g -Werror -Wall -std=c++11
INCLUDES:=-I. -I$(GOOGLE_TEST_INCLUDE)
LIBS:=-L$(GOOGLE_TEST_LIB_DIR) -l$(GOOGLE_TEST_LIB) -lpthread
OBJDIR=obj
SRC:=main.cpp DomBuilder.cpp TestDomBuilder.cpp XmlBuilder.cpp TestXmlBuilder.cpp
OBJ:= $(patsubst %.cpp,$(OBJDIR)/%.o,$(SRC))
TARGETDIR=bin
TARGET=OutputBuilderTest


$(OBJDIR)/%.o: %.cpp
	@mkdir -p $(OBJDIR)
	$(CC) $(CFLAGS) $(INCLUDES) -c -o $@ $<

$(TARGETDIR)/$(TARGET): $(OBJ)
	@mkdir -p $(TARGETDIR)
	$(CC) -o $@ $^ $(LIBS)

.PHONY: all clean

clean:
	@rm -rf $(TARGETDIR) $(OBJDIR)

