#!/bin/bash
XIBS="Xibs/UI/*.xib
Xibs/TouchID/*.xib
Xibs/SMS/*.xib"
 
for i in $XIBS
do
  echo "Compiling `basename $i`..."
  ibtool --compile Nibs/`basename -s .xib $i`.nib $i
done